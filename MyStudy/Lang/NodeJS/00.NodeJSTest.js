const basket = {
  status: {
    name: 'apple',
    count: 5,
  },
  getFruit() {
    this.status.count--;
    return this.status.count;
  },
};
var getFruit = basket.getFruit;
var count = basket.status.count;

//const { getFruit, status: { count } } = basket;
console.log(this);