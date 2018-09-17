import Vue from 'vue';

Vue.filter('score', function (value, decimals) {
  if (value === 0) {
    return 0;
  }
  if (!value) {
    return "--";
  }

  if (!decimals) {
    decimals = 0;
  }

  value = Math.round(value * Math.pow(10, decimals)) / Math.pow(10, decimals);
  return value;
});
