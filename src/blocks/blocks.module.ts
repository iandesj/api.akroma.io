import { Module } from '@nestjs/common';
import { MongooseModule } from '@nestjs/mongoose';

import { BlocksController } from './blocks.controller';
import { BlockSchema } from './schemas/block.schema';
import { BlocksService } from './services/blocks.service';

@Module({
  imports: [
    MongooseModule.forFeature([
      { name: 'Block', schema: BlockSchema },
    ]),
  ],
  controllers: [
    BlocksController,
  ],
  components: [
    BlocksService,
  ],
})
export class BlocksModule { }
