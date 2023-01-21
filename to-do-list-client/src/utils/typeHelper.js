class TypeHelper {

  check(data) {
    if (this.isNull(data)) return 'null';
    else if (this.isUndefined(data)) return 'undefined';
    else if (this.isArray(data)) return 'array';
    else if (this.isObject(data)) return 'object';
    else if (this.isString(data)) return 'string';
    else if (this.isNumber(data)) return 'number';
    
    throw new Error('Uncaught Type');
  }

  isArray(data) {
    return Array.isArray(data);
  }

  isObject(data) {
    return typeof (data) === 'object';
  }

  isNumber(data) {
    return typeof (data) === 'number';
  }

  isString (data) {
    return typeof (data) === 'string';
  }

  isNull (data) {
    return data === null;
  }

  isNaN (data) {
    return Number.isNaN(data);
  }

  isUndefined(data) {
    return data === undefined;
  }

  AddNumber(d1, d2) {
    return +d1 + +d2;
  }

  AddString(d1, d2) {
    return "" + d1 + d2;
  }
}

export default new TypeHelper();