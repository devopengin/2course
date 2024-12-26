class Sudoku {
  constructor() {
    this.initialBoard = this.createEmptyBoard();
    this.board = this.cloneBoard(this.initialBoard);
  }

  createEmptyBoard() {
    const board = [];
    for (let i = 0; i < 9; i++) {
      const row = [];
      for (let j = 0; j < 9; j++) {
        row.push(0);
      }
      board.push(row);
    }
    return board;
  }

  cloneBoard(board) {
    return board.map(row => [...row]);
  }

  resetBoard() {
    this.board = this.cloneBoard(this.initialBoard);
    console.log("Игровое поле сброшено");
  }

  checkRow(rowIndex) {
    const row = this.board[rowIndex];
    const seen = new Set();
    for (let num of row) {
      if (num !== 0 && seen.has(num)) return false;
      seen.add(num);
    }
    return true;
  }

  checkColumn(colIndex) {
    const seen = new Set();
    for (let row = 0; row < 9; row++) {
      const num = this.board[row][colIndex];
      if (num !== 0 && seen.has(num)) return false;
      seen.add(num);
    }
    return true;
  }

  checkSquare(squareIndex) {
    const seen = new Set();
    const startRow = Math.floor(squareIndex / 3) * 3;
    const startCol = (squareIndex % 3) * 3;

    for (let row = startRow; row < startRow + 3; row++) {
      for (let col = startCol; col < startCol + 3; col++) {
        const num = this.board[row][col];
        if (num !== 0 && seen.has(num)) return false;
        seen.add(num);
      }
    }
    return true;
  }

  validateBoard() {
    let isValid = true;

    for (let i = 0; i < 9; i++) {
      if (!this.checkRow(i)) {
        console.log(`Ошибка в строке ${i + 1}`);
        isValid = false;
      }
      if (!this.checkColumn(i)) {
        console.log(`Ошибка в столбце ${i + 1}`);
        isValid = false;
      }
      if (!this.checkSquare(i)) {
        console.log(`Ошибка в квадрате ${i + 1}`);
        isValid = false;
      }
    }

    return isValid;
  }

  generateBoard() {
    const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    const fillBoard = (row, col) => {
      if (row === 9) return true;
      if (col === 9) return fillBoard(row + 1, 0);

      for (let num of this.shuffleArray(numbers)) {
        if (this.isSafe(row, col, num)) {
          this.board[row][col] = num;
          if (fillBoard(row, col + 1)) return true;
          this.board[row][col] = 0;
        }
      }
      return false;
    };

    this.resetBoard();
    fillBoard(0, 0);
    console.log("Игровое поле сгенерировано");
  }

  isSafe(row, col, num) {
    for (let i = 0; i < 9; i++) {
      if (
        this.board[row][i] === num ||
        this.board[i][col] === num ||
        this.board[
          Math.floor(row / 3) * 3 + Math.floor(i / 3)
        ][Math.floor(col / 3) * 3 + (i % 3)] === num
      ) {
        return false;
      }
    }
    return true;
  }

  shuffleArray(array) {
    for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]];
    }
    return array;
  }

  displayBoard() {
    const horizontalLine = "+-------+-------+-------+";
    console.log(horizontalLine);
  
    for (let row = 0; row < 9; row++) {
      let formattedRow = "| ";
      for (let col = 0; col < 9; col++) {
        const cell = this.board[row][col] === 0 ? '.' : this.board[row][col];
        formattedRow += cell + " ";
        if ((col + 1) % 3 === 0) formattedRow += "| ";
      }
      console.log(formattedRow.trim());
      if ((row + 1) % 3 === 0) console.log(horizontalLine);
    }
  }
}

const game = new Sudoku();
game.generateBoard();
game.displayBoard();
