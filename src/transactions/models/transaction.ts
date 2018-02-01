import { Document } from 'mongoose';

export interface Transaction extends Document {
  hash: string;
  nonce: number;
  blockHash: string | null;
  blockNumber: number;
  transactionIndex: number;
  from: string;
  to: string | null;
  value: string;
  gas: number;
  gasPrice: string;
  timestamp: number;
  input: string;
}
