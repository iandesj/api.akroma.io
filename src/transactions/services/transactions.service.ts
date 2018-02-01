import { Component } from '@nestjs/common';
import { InjectModel } from '@nestjs/mongoose';
import { Model } from 'mongoose';

import { Transaction } from '../models/transaction';
import { TransactionSchema } from '../schemas/transaction.schema';

@Component()
export class TransactionsService {
  constructor(
    @InjectModel(TransactionSchema) private readonly transactionModel: Model<Transaction>,
  ) { }

  async getAll(
    beforeTimestamp: number = Infinity,
    limit: number = 100,
  ): Promise<Transaction[]> {
    const conditions: any = {};

    if (beforeTimestamp !== Infinity) {
      conditions.timestamp = { $lt: beforeTimestamp };
    }

    const boundedLimit = Math.max(1, Math.min(200, limit));

    return await this.transactionModel
      .find(conditions)
      .limit(boundedLimit)
      .sort({ timestamp: 'desc' })
      .exec();
  }

  async findOne(hash: string): Promise<Transaction> {
    return await this.transactionModel
      .findOne({ hash })
      .exec();
  }
}
