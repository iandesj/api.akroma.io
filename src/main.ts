import { config } from 'dotenv';
config();

import { NestFactory } from '@nestjs/core';
import { DocumentBuilder, SwaggerModule } from '@nestjs/swagger';

import { ApplicationModule } from './app.module';

const version = require('../package.json').version;

async function bootstrap() {
  const app = await NestFactory.create(ApplicationModule);

  const options = new DocumentBuilder()
    .setTitle('Akroma Blockchain API')
    .setVersion(version)
    .setDescription('An API to get insights into the Akroma network')
    .build();

  const document = SwaggerModule.createDocument(app, options);
  SwaggerModule.setup('/api', app, document);

  await app.listen(3000);
}

bootstrap();
