using System;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Persistence.SQL;
using Akroma.Persistence.SQL.Model;
using Akroma.Web3;
using Akroma.Web3.Model;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Import
{
    public class ImportService
    {
        private readonly AkromaContextFactory _contextFactory;
        private readonly Web3.Web3 _web3;

        public ImportService(AkromaContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _web3 = new Web3.Web3();
        }

        public async Task Execute()
        {
            await GetBlock();
        }

        private async Task GetBlock(string blockNumber = "latest")
        {
            using (var context = _contextFactory.Create())
            {
                Console.WriteLine($"Importing block number: {blockNumber}");
                var block = await _web3.Eth.GetBlockByNumberWithTransactions(blockNumber);
                if (block?.Result == null)
                {
                    throw new Exception("unable to get blocks from geth");
                }
                var saved = await SaveBlock(context, block.Result);

                if (saved.Exists)
                {
                    Console.WriteLine($"block number: {blockNumber} exists....we done.");
                    return;
                }

                await SaveTransactions(context, block.Result);
                var nextBlock = block.Result.Number.Value - 1;
                if (nextBlock <= 0)
                {
                    return;
                }
                await GetBlock(nextBlock.ToString());
            }

        }

        private async Task<SaveResult> SaveTransactions(AkromaContext context, BlockWithTransactions unsavedBlock)
        {
            if (!unsavedBlock.Transaction.Any())
            {
                return SaveResult.Success();
            }

            foreach (var transaction in unsavedBlock.Transaction)
            {
                var aka = UnitConversion.Convert.FromWeiToBigDecimal(transaction.Value);
                var toSave = new TransactionEntity
                {
                    Hash = transaction.Hash,
                    Nonce = transaction.Nonce.HexValue,
                    BlockHash = transaction.BlockHash,
                    BlockNumber = int.Parse(transaction.BlockNumber.Value.ToString()),
                    TransactionIndex = int.Parse(transaction.TransactionIndex.Value.ToString()),
                    From = transaction.From,
                    To = transaction.To,
                    Value = decimal.Parse(aka.ToString()),
                    Gas = transaction.Gas.HexValue,
                    GasPrice = transaction.GasPrice.HexValue,
                    Timestamp = long.Parse(unsavedBlock.Timestamp.Value.ToString()),
                    Input = transaction.Input
                };
                context.Transactions.Add(toSave);
                await context.SaveChangesAsync();
            }
            return SaveResult.Success();
        }

        private async Task<SaveResult> SaveBlock(AkromaContext context, Block unsavedBlock)
        {
            var blockNumber = unsavedBlock.Number.Value;
            //TODO: THIS IS SLOW AF.
            var exists = await context.Blocks.AnyAsync(b => b.Number == blockNumber);
            if (exists)
            {
                return SaveResult.Success(true);
            }

            var toSave = new BlockEntity
            {
                Number = int.Parse(unsavedBlock.Number.Value.ToString()),
                Hash = unsavedBlock.Hash,
                ParentHash = unsavedBlock.ParentHash,
                Nonce = unsavedBlock.Nonce,
                Sha3Uncles = unsavedBlock.Sha3Uncles,
                LogsBloom = unsavedBlock.LogsBloom,
                TransactionsRoot = unsavedBlock.TransactionsRoot,
                StateRoot = unsavedBlock.StateRoot,
                Miner = unsavedBlock.Miner,
                Difficulty = unsavedBlock.Difficulty.HexValue,
                TotalDifficulty = unsavedBlock.TotalDifficulty.HexValue,
                Size = int.Parse(unsavedBlock.Size.Value.ToString()),
                ExtraData = unsavedBlock.ExtraData,
                GasLimit = long.Parse(unsavedBlock.GasLimit.Value.ToString()),
                GasUsed = long.Parse(unsavedBlock.GasUsed.Value.ToString()),
                Timestamp = int.Parse(unsavedBlock.Timestamp.Value.ToString())
            };
            foreach (var uncle in unsavedBlock.Uncles)
            {
                toSave.Uncles.Add(new UncleEntity
                {
                    Block = toSave,
                    Data = uncle
                });
            }
            context.Blocks.Add(toSave);
            var saved = await context.SaveChangesAsync();
            return new SaveResult
            {
                Exists = false,
                Ok = saved == 1
            };
        }
    }
}
