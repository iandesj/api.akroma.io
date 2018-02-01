import { Module } from '@nestjs/common';
import { MongooseModule } from '@nestjs/mongoose';

import { BlocksModule } from './blocks/blocks.module';
import { TransactionModule } from './transactions/transactions.module';

@Module({
  imports: [
    MongooseModule.forRoot(process.env.MONGO_DB_URL),
    BlocksModule,
    TransactionModule,
  ],
})
export class ApplicationModule { }
