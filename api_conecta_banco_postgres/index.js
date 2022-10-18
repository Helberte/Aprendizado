const express = require('express');
const app = express();
const postgres = require('pg');

const PORT = process.env.PORT || 5540;

const config = {
  host: 'ec2-34-200-205-45.compute-1.amazonaws.com',
  user: 'njcivcfqipndea',
  password: '970714380e2667806bd93cb78cc41481950d530628450adc4d9f4e9643486887',
  database: 'dd9mnlal8p6427',
  port: '5432',
  ssl: true
}

const client = new postgres.Client(config);


app.get('/', (req, res) => {
  client.connect(erro => {
    if (erro) {
      throw erro;
    }
    else{
      query_services();
    }  
  })
})


function query_services(){
  const query = 'select * from servicos';

  client.query(query).then(res => {
    const rows = res.rows;

    rows.map(row => {
      console.log(`${JSON.stringify(row)}`);
    });

    process.exit();


  }).catch(erro => {
    console.log(erro);
  })
}
 

app.listen(PORT, _ => console.log(`server up port ${PORT}`));