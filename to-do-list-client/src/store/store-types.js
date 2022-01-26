import _ from 'lodash'

function generateConstMap(...data) {
  return _.reduce(data, (a, v) => Object.assign(a, { [_.camelCase(v)]: v }), {});
}


// export const USER = generateConstMap(
//   'SET_USER'
// )

export const POPUP = generateConstMap(
  'GET_POPUP_COUNT',
  'GET_DEFAULT_Z_INDEX'
);