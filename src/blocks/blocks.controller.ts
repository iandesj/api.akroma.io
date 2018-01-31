import { Controller, Get, HttpStatus, Param, Query } from '@nestjs/common';
import { ApiImplicitQuery, ApiResponse, ApiUseTags } from '@nestjs/swagger';

import { Block } from './models/block';
import { BlocksService } from './services/blocks.service';

@ApiUseTags('Blocks')
@Controller('blocks')
export class BlocksController {
  constructor(
    private readonly blocksComponent: BlocksService,
  ) { }

  @Get()
  @ApiImplicitQuery({
    name: 'before_block',
    required: false,
    description: 'Search for blocks before given block number',
    type: 'number',
  })
  @ApiImplicitQuery({
    name: 'limit',
    required: false,
    description: 'Limit results (default: 100, max: 200)',
    type: 'number',
  })
  @ApiResponse({ status: HttpStatus.OK })
  async getAll(
    @Query('before_block') beforeBlockId: number = Infinity,
    @Query('limit') limit: number = 100,
  ): Promise<Block[]> {
    return await this.blocksComponent
      .getAll(beforeBlockId, limit);
  }

  @Get(':id')
  @ApiResponse({ status: HttpStatus.OK })
  async findOne(@Param('id') blockId: number): Promise<Block> {
    return await this.blocksComponent
      .findOne(blockId);
  }
}
