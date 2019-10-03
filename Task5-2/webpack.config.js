const HtmlWebPackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CopyPlugin = require('copy-webpack-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');

module.exports = {
    optimization: {
        minimizer: [ new OptimizeCSSAssetsPlugin({})],
    },
    devtool:"source-map",
    module:{
        rules:[
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
                    MiniCssExtractPlugin.loader,
                    { 
                        loader: "css-loader", 
                        options: { 
                            sourceMap: true, 
                        }
                    },                         
                    "postcss-loader",               
                    "sass-loader"
                ]
            },
        ]
    },
    plugins: [
        new CopyPlugin([
            { 
                from: 'src/images', 
                to: './images' ,
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