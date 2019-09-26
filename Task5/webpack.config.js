const HtmlWebPackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CopyPlugin = require('copy-webpack-plugin');

module.exports = {
    module:{
        rules:[
            {
                test: /\.html$/,
                use:[
                    {
                        loader: "html-loader",
                        options: {minimize : true}
                    }
                ]
            },
            {
                test: /\.(png|jpg)$/,
                use:[
                    'file-loader'
                ]
            },
            {
                test: /\.scss$/,
                use: [
                    "style-loader",
                    "css-loader",
                    "sass-loader"
                ]
            }

        ]
    },
    plugins: [
        new CopyPlugin([
            { 
                from: 'src/images/*', 
                to: '' ,
                force: true,
            },
        ]),
        new HtmlWebPackPlugin({
            template: "./src/index.html",
            filename: "./index.html"
        }),
        new MiniCssExtractPlugin({
            filename: "[name].css",
            chunkFilename: "[id].css"
        }),
        
    ]
}