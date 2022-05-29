const process = require('process')

const { Client, query } = require('faunadb')

const config = require('./config.json');

/* configure faunaDB Client with our secret */
const client = new Client({
  secret: process.env.FAUNADB_SERVER_SECRET ? process.env.FAUNADB_SERVER_SECRET : config.secret,
})

/* export our lambda function as named "handler" export */
const handler = async (event) => {
  /* parse the string body into a useable JS object */
  let data = JSON.parse(event.body)
  data = data.map(item => {
    return {
      Provider: 0,
      Ingredients: [],
      GrossWeight: 0,
      Title: item.Title,
      Price: item.Price,
      Image: item.Image,
      NutritionalValues: [],
      Tags: [],
    }
  });
  console.log('Function `create` invoked', data)
  /* construct the fauna query */
  try {
    const response = await client.query(query.Call(query.Function("CreateProductBulk"), data))
    console.log('success', response)
    /* Success! return the response with statusCode 200 */
    return {
      statusCode: 200,
      body: JSON.stringify(response),
    }
  } catch (error) {
    console.log('error', error)
    /* Error! return the error with statusCode 400 */
    return {
      statusCode: 400,
      body: JSON.stringify(error),
    }
  }
}

module.exports = { handler }
