import {config} from 'dotenv';

config();

export const PORT = 3333;
export const SUPABASE_URL = process.env.SUPABASE_URL ?? '';
export const SUPABASE_KEY = process.env.SUPABASE_KEY ?? '';