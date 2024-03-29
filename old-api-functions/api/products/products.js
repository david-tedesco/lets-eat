const createRoute = require('./create')
const createAllRoute = require('./create-all')
const deleteRoute = require('./delete')
const readRoute = require('./read')
const readAllRoute = require('./read-all')
const updateRoute = require('./update')

const handler = async (event, context) => {
  const path = event.path.replace(/\.netlify\/functions\/[^/]+/, '')
  const segments = path.split('/').filter(Boolean)

  switch (event.httpMethod) {
    case 'GET':
      // e.g. GET /.netlify/functions/products
      if (segments.length === 0) {
        return readAllRoute.handler(event, context)
      }
      // e.g. GET /.netlify/functions/products/123456
      if (segments.length === 1) {
        const [id] = segments
        event.id = id
        return readRoute.handler(event, context)
      }
      return {
        statusCode: 500,
        body: 'too many segments in GET request, must be either /.netlify/functions/products or /.netlify/functions/products/123456',
      }

    case 'POST':
      // e.g. POST /.netlify/functions/products with a body of key value pair objects, NOT strings
      if (segments.length === 1 && segments[0] === 'all') {
        return createAllRoute.handler(event, context)
      }
      return createRoute.handler(event, context)
    case 'PUT':
      // e.g. PUT /.netlify/functions/products/123456 with a body of key value pair objects, NOT strings
      if (segments.length === 1) {
        const [id] = segments
        event.id = id
        return updateRoute.handler(event, context)
      }
      return {
        statusCode: 500,
        body: 'invalid segments in POST request, must be /.netlify/functions/products/123456',
      }

    case 'DELETE':
      // e.g. DELETE /.netlify/functions/products/123456
      if (segments.length === 1) {
        const [id] = segments
        event.id = id
        return deleteRoute.handler(event, context)
      }
      return {
        statusCode: 500,
        body: 'invalid segments in DELETE request, must be /.netlify/functions/products/123456',
      }
    default:
      return {
        statusCode: 500,
        body: 'unrecognized HTTP Method, must be one of GET/POST/PUT/DELETE',
      }
  }
}

module.exports = { handler }
