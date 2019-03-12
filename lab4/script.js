var Runge = function(x0, y0, end, accuracy, funcName) {
  this.xs = [x0];
  this.ys = [y0];
  k1 = 0, k2 = 0, k3 = 0, k4 = 0;
  if (accuracy < 1) {
    step = Math.round((accuracy ** (1 / 4)) * 1000) / 1000;
  } else {
    step = accuracy;
  }
  n = ((end - x0) / step) + 1;
  for (var i = 1; i < n; i++) {
    k1 = Function(x0, y0, funcName);
    k2 = Function(x0 + step / 2, y0 + step * k1 / 2, funcName);
    k3 = Function(x0 + step / 2, y0 + step * k2 / 2, funcName);
    k4 = Function(x0 + step, y0 + step * k3, funcName);

    x0 += step;
    y0 = y0 + step * (k1 + 2 * k2 + 2 * k3 + k4) / 6;

    this.xs.push(x0);
    this.ys.push(y0);
  }
}

function Function(x, y, funcName) {
  switch (funcName) {
    case 'sinx':
      return Math.sin(x);
      break;
    case 'cosx':
      return Math.cos(x);
      break;
    case 'x^2':
      return (x * x);
      break;
    case 'x^2-2y':
      return (x * x - 2 * y);
      break;
    default:
      return Math.sin(x);
  }
}
