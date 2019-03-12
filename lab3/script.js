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

var Lagrange = function(x1, y1, x2, y2) {
  this.xs = [x1, x2];
  this.ys = [y1, y2];
  this.ws = [];
  this._updateWeights();
}

Lagrange.prototype.addPoint = function(x, y) {
  this.xs.push(x);
  this.ys.push(y);
  bubbleSort(this.xs, this.ys);
  this._updateWeights();
}

Lagrange.prototype._updateWeights = function() {
  var k = this.xs.length;
  var w;

  for (var j = 0; j < k; ++j) {
    w = 1;
    for (var i = 0; i < k; ++i) {
      if (i != j) {
        w *= this.xs[j] - this.xs[i];
      }
    }
    this.ws[j] = 1 / w;
  }
}

/**
 * Calculate L(x)
 */
Lagrange.prototype.valueOf = function(x) {
  var a = 0;
  var b = 0;
  var c = 0;

  for (var j = 0; j < this.xs.length; ++j) {
    if (x != this.xs[j]) {
      a = this.ws[j] / (x - this.xs[j]);
      b += a * this.ys[j];
      c += a;
    } else {
      return this.ys[j];
    }
  }

  return b / c;
}
