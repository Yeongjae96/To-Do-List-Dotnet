import moment from 'moment';


/*
  isAutoRegistConfig: false가 되면, this.$Util이름 으로 자동등록을 하지 않는다.
  기본값 True
*/

const DateUtils = {
  isAutoRegist: true,  
  getToday,
}

export function getToday(format = 'yyyy-MM-DD') {
  return moment().format(format);
}

export default DateUtils;