import express from 'express';
import { errorHandler } from '@/middleware/errorHandler';

export const app = express();

app.use(express.json());

// Mount routers here
// app.use('/api/users', userRouter);

app.use(errorHandler);
