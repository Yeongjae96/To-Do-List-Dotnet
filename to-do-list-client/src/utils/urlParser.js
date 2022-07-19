/*
  기본적으로 배열은 모든 항목을 찾아들어간다.  (배열의 항목이 객체나 배열이 없을떄까지 밑으로 파고들어간다.)
  객체는 모든 키값의 항목을 찾아들어간다.  (객체의 value값이 객체나 배열이 없을때까지 밑으로 파고들어간다.)
   
  기본값만 존재하는것을 확인하면 

  처음에 객체를 던져준다.
  그때는 기본 객체일때는
  key=value 로 만들어주는데,

  첫항목일때는 ?~ 두번째항목부터는 &를 붙여줘야한다.

  2depth 이상이되면
  2depth의 속성명을 

*/
import th from './typeHelper';

class UrlParser {
  constructor() {}

  parse() {
    throw new Error('Not Implemented Methods');
  }

  #prefix(idx) {
    return idx === 0 ? '' : '&';
  }

  #stringifyObject({ key: pKey, value, idx: pIdx }) {
    const keys = Object.keys(value);
    const result = keys.reduce((prev, key, idx) => prev + this.#prefix(idx) + (pKey ? `${pKey}[${pIdx}].` : '') + this.stringify({
      key, value: value[key]
    }), '')

    return result;
  }
  
  #stringifyArray({ key: pKey , value }) {
    let result = '';
    result += value.reduce((prev, cur, idx) => {
      return prev + this.#prefix(idx) + this.stringify({ key: pKey, value: cur, idx });
    }, result);

    return result;
  }
  /*
  * value값이 string이면
  * key=value
  */
  #stringifyString({ key, value, idx }) {
    return `${key}=${value}`;
  }

  /*
  * value값이 비었을때(null, undefined)
  * key=
  */
  #stringifyEmpty({ key }) {
    return `${key}=`;
  }

  stringify({ key, value, idx }) { 
    let result = '';
    if (th.isNull(value) || th.isUndefined(value)) { // 값이 없을 때 
      result = this.#stringifyEmpty({ key });
    } else if (th.isArray(value)) { // 배열일때 
      result = this.#stringifyArray({ key, value, });
    } else if (th.isObject(value)) { // 객체일때 
      result = this.#stringifyObject({ key, value, idx });
    } else { // string, number일때 
      result = this.#stringifyString({ key, value, idx });
    } 

    return result;
  }
}

export default new UrlParser();