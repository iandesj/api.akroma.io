import { Module } from '@nestjs/common';
import { MongooseModule } from '@nestjs/mongoose';

import { BlocksModule } from './blocks/blocks.module';

@Module({
  imports: [
    MongooseModule.forRoot(process.env.MONGO_DB_URL),
    BlocksModule,
  ],
})
export class ApplicationModule { }
