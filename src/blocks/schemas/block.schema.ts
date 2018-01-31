import * as mongoose from 'mongoose';

export const BlockSchema = new mongoose.Schema({
  number: { type: Number, index: { unique: true } },
  hash: String,
  parentHash: String,
  nonce: String,
  sha3Uncles: String,
  logsBloom: String,
  transactionsRoot: String,
  stateRoot: String,
  miner: String,
  difficulty: String,
  totalDifficulty: String,
  size: Number,
  extraData: String,
  gasLimit: Number,
  gasUsed: Number,
  timestamp: Number,
  uncles: [String],
});
