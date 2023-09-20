import pool from "./connection";

async function testConnection() {
    try {
        const client = await pool.connect();
        console.log('deu bommm!!')
    } catch (error) {
        console.error('deu rumm :(', error);
    }

    await pool.end()
}

export default testConnection;