import { Component } from '@nestjs/common';
import { InjectModel } from '@nestjs/mongoose';
import { Model } from 'mongoose';

import { Block } from '../models/block';
import { BlockSchema } from '../schemas/block.schema';

@Component()
export class BlocksService {
  constructor(
    @InjectModel(BlockSchema) private readonly blocksModel: Model<Block>,
  ) { }

  async getAll(
    beforeBlockNumber: number = Infinity,
    limit: number = 100,
  ): Promise<Block[]> {
    const conditions: any = {};

    if (beforeBlockNumber !== Infinity) {
      conditions.number = { $lt: beforeBlockNumber };
    }

    const boundedLimit = Math.max(1, Math.min(200, limit));

    return await this.blocksModel
      .find(conditions)
      .limit(boundedLimit)
      .sort({ timestamp: 'desc' })
      .exec();
  }

  async findOne(number: number): Promise<Block> {
    return await this.blocksModel
      .findOne({ number })
      .exec();
  }
}
