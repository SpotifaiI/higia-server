import {createClient} from "@supabase/supabase-js";
import {Database} from '../../types/db.types';
import {SUPABASE_KEY, SUPABASE_URL} from "../../utils/constants";

const supabase = createClient<Database>(SUPABASE_URL, SUPABASE_KEY);

export default supabase;
