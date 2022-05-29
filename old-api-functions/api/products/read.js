/* Import faunaDB sdk */
const process = require('process')

const { Client, query } = require('faunadb')

const config = require('./config.json');

/* configure faunaDB Client with our secret */
const client = new Client({
  secret: process.env.FAUNADB_SERVER_SECRET ? process.env.FAUNADB_SERVER_SECRET : config.secret,
})


const handler = async (event) => {
  const { id } = event
  console.log(`Function 'read' invoked. Read id: ${id}`)

  try {
    const response = await client.query(query.Call(query.Function("GetProductById"), id))
    response.Ingredients = response.Ingredients.map(ingredient => {
      return {
        Id: ingredient.ref.id,
        ...ingredient.data
      }
    });
    response.NutritionalValues = response.NutritionalValues.map(nutritionalValue => {
      return {
        Id: nutritionalValue.ref.id,
        ...nutritionalValue.data
      }
    });
    response.Tags = response.Tags.map(tag => {

      return {
        Id: tag.ref.id,
        ...tag.data
      }
    });
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
