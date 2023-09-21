import supabase from "./connection";

async function testConnection() {
  try {
    const { data, error } = await supabase.from("user").select("*");

    if (error) console.log("erro na busca :|");
    console.log("deu bommm!!");

  } catch (error) {
    console.error("deu rumm :(", error);
  }
}

export default testConnection;
