import * as mongoose from 'mongoose';

export const TransactionSchema = new mongoose.Schema({
  hash: { type: String, index: { unique: true } },
  nonce: Number,
  blockHash: String,
  blockNumber: Number,
  transactionIndex: Number,
  from: String,
  to: String,
  value: String,
  gas: Number,
  gasPrice: String,
  timestamp: Number,
  input: String,
});
