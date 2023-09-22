import supabase from "../services/supabase";

const db = {
  connection: supabase,
  user: supabase.from('user'),
  task: supabase.from('task'),
  user_task: supabase.from('user_task')
};

export default db;
