import { Module } from '@nestjs/common';
import { MongooseModule } from '@nestjs/mongoose';

import { TransactionSchema } from './schemas/transaction.schema';
import { TransactionsService } from './services/transactions.service';
import { TransactionsController } from './transactions.controller';

@Module({
  imports: [
    MongooseModule.forFeature([
      { name: 'Transaction', schema: TransactionSchema },
    ]),
  ],
  controllers: [
    TransactionsController,
  ],
  components: [
    TransactionsService,
  ],
})
export class TransactionModule { }
