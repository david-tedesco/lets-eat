/* Import faunaDB sdk */
const process = require('process')

const { Client, query } = require('faunadb')

const config = require('./config.json');

/* configure faunaDB Client with our secret */
const client = new Client({
  secret: process.env.FAUNADB_SERVER_SECRET ? process.env.FAUNADB_SERVER_SECRET : config.secret,
})


const handler = async () => {
  console.log('Function `read-all` invoked')

  try {
    const response = await client.query(query.Map(query.Paginate(query.Match(query.Index("Products"))), ref => query.Get(ref)));
    const data = response.data.map(item => {
      return {
        Id: item.ref.value.id,
        ...item.data
      }
    });

    data.forEach((item, i) => {
      data[i].Ingredients = Object.values(item.Ingredients).map(ingredient => {
        return ingredient.id
      });
      data[i].NutritionalValues = Object.values(item.NutritionalValues).map(nutritionalValue => {
        return nutritionalValue.id
      });
      data[i].Tags = Object.values(item.Tags).map(tag => {
        return tag.id
      }
      );
    });
    return {
      statusCode: 200,
      body: JSON.stringify(data),
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
