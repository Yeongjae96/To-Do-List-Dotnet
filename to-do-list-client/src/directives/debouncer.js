//debouncer.js
/*
      This is the typical debouncer function that receives
      the "callback" and the time it will wait to emit the event
    */

const debouncer = (fn, delay) => {
  let timeoutID = null;
  return (...args) => {
    if (timeoutID) clearTimeout(timeoutID);
    timeoutID = setTimeout(() => {
      fn.apply(this, args);
    }, delay);
  };
};
/*
  this function receives the element where the directive
  will be set in and also the value set in it
  if the value has changed then it will rebind the event
  it has a default timeout of 500 milliseconds
*/

function inputDebounce(el, binding) {
  if (binding.value !== binding.oldValue) {
    el.oninput = debouncer(function () {
      el.dispatchEvent(new Event("change"));
    }, parseInt(binding.value) || 500);
  }
}

const enterDebounce = (el, binding) => {
  el.onkeypress = debouncer((e) => {
    if (e.keyCode !== 13) return;
    el.dispatchEvent(new Event("enter"));
  }, parseInt(binding.value) || 500);
};

module.exports = {
  inputDebounce,
  enterDebounce,
};
