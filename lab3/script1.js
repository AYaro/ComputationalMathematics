
var Lagrange = function(x1, y1, x2, y2) {
  this.xs = [x1, x2];
  this.ys = [y1, y2];
}

Lagrange.prototype.addPoint = function(x, y) {
  this.xs.push(x);
  this.ys.push(y);
  bubbleSort(this.xs, this.ys);
}

Lagrange.prototype.interpolate = function(x) {
  var length = this.xs.length;
  var result = 0;

  for (var i = 0; i < length; i++) {
    var term = this.ys[i];
    for (var j = 0; j < length; j++) {
      if (j != i) {
        term =  term*(x - this.xs[j])/(this.xs[i]-this.xs[j]);
      }
    }
    result += term;
  }
  return result;
}

function bubbleSort(arr1, arr2) {
  var sorted = false
  while (!sorted) {
    sorted = true;
    arr1.forEach(function(element, index, array) {
      var element2;
      if (element > array[index + 1]) {
        array[index] = array[index + 1];
        array[index + 1] = element;
        element2 = arr2[index]
        arr2[index] = arr2[index + 1];
        arr2[index + 1] = element2;
        sorted = false;
      }
    });
  }
}
