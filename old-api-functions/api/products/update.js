/* Import faunaDB sdk */
const process = require('process')

const { Client, query } = require('faunadb')

const config = require('./config.json');

/* configure faunaDB Client with our secret */
const client = new Client({
  secret: process.env.FAUNADB_SERVER_SECRET ? process.env.FAUNADB_SERVER_SECRET : config.secret,
})


const handler = async (event) => {
  const data = JSON.parse(event.body)
  const { id } = event
  console.log(`Function 'update' invoked. update id: ${id}`)
  try {
    const response = await client.query(query.Call(query.Function("UpdateProduct"), id, 0, [], 0, data.Title, data.Price, data.Image, [], [], data.Availability))
    console.log('success', response)
    return {
      statusCode: 200,
      body: JSON.stringify(response),
    }
  } catch (error) {
    console.log('error', error)
    return {
      statusCode: 400,
      body: JSON.stringify(error),
    }
  }
}

module.exports = { handler }
