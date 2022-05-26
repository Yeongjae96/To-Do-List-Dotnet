module.exports = {
  "root": true,
  "env": {
    "node": true
  },
  "extends": [
    "plugin:vue/vue3-essential",
    "eslint:recommended"
  ],
  "parserOptions": {
    "parser": "babel-eslint"
  },
  "rules": {
    "vue/no-unused-components": [
      "error",
      {
        "ignoreWhenBindingPresent": true
      }
    ],
  "vue/no-dupe-keys": 0,
  }
}