const UEClient = require("./Client").UEClient;
const Store = require("./Get_Product").Store;
const axios = require('axios');



const handler = async (event, context) => {
  const client = new UEClient();

  client.setEmail("arthur.guerquin@gmail.com");
  client.setPassword("Letseat!");

  await client.authenticate();

  const store = new Store(client);

  const products = await store.getProducts('live', 'plats-cuisines-group');

  console.log(products);



  // send the products array to the database using a post request using the route /products/all.
   await axios.post('https://lets-eat-test.netlify.app/.netlify/functions/products/all', body = products);

  return {
    statusCode: 200
  }
}

module.exports = { handler }
