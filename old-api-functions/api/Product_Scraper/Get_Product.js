const fs = require('fs');
const axios = require('axios');
const { UEClient } = require('./Client');

class Store {
    constructor (client) {
        this.token = client.token;

    }

    async getProducts(store, type) {
        const products = [];

        const list = await axios.get(`https://api-gateway.frichti.co/v3/menu/rootslug/b2c/hubs/35/collections/plats-cuisines-market-group`, {
            headers: {
                'Authorization': `Bearer ${this.token}`
            }
        }).catch(function (error) {
            console.log(error);
        });

        // // write the stringified list.data in a file.
        // fs.writeFile('list.json', JSON.stringify(list.data.items), function (err) {
        //      if (err) throw err;
        //      console.log('Saved!');
        // });

        Object.keys(list.data.items).forEach(async (key) => {
            for (let item of list.data.items) {
                for (let product of item.items) {
                    if (product.product !== undefined) {
                        products.push({
                            Title: product.product.title,
                            Price: (parseFloat(product.product.price)/100).toFixed(2),
                            Image: product.product.image
                         })
                    }
                }
            }
        });

    //     fs.writeFile('products.json', JSON.stringify(products), function (err) {
    //         if (err) throw err;
    //         console.log('Saved!');
    //    });
        return(products);
    }
}

exports.Store = Store;