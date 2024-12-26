class Sudoku {
    constructor() {
      this.initialBoard = this.createEmptyBoard();
      this.board = this.cloneBoard(this.initialBoard);
    }
  
    // Создание пустого поля
    createEmptyBoard() {
      const board = [];
      for (let i = 0; i < 9; i++) {
        const row = [];
        for (let j = 0; j < 9; j++) {
          row.push(0); // Все клетки пустые (0)
        }
        board.push(row);
      }
      return board;
    }
  
    // Клонирование поля (для сброса или других целей)
    cloneBoard(board) {
      return board.map(row => [...row]);
    }
  
    // Сброс поля
    resetBoard() {
      this.board = this.cloneBoard(this.initialBoard);
      console.log("Игровое поле сброшено");
    }
  
    // Проверка строки
    checkRow(rowIndex) {
      const row = this.board[rowIndex];
      const seen = new Set();
      for (let num of row) {
        if (num !== 0 && seen.has(num)) return false;
        seen.add(num);
      }
      return true;
    }
  
    // Проверка столбца
    checkColumn(colIndex) {
      const seen = new Set();
      for (let row = 0; row < 9; row++) {
        const num = this.board[row][colIndex];
        if (num !== 0 && seen.has(num)) return false;
        seen.add(num);
      }
      return true;
    }
  
    // Проверка 3x3 квадрата
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
  
    // Проверка всего поля на ошибки
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
  
    // Генерация решенного поля
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
  
    // Функция для случайного удаления значений в некоторых клетках (для игры)
    createPuzzle(difficulty = 40) {
      // difficulty — это количество пустых клеток, которые мы оставим
      const puzzle = this.cloneBoard(this.board);
      let cellsCleared = 0;
  
      while (cellsCleared < difficulty) {
        const row = Math.floor(Math.random() * 9);
        const col = Math.floor(Math.random() * 9);
  
        // Если клетка еще пустая, очищаем её
        if (puzzle[row][col] !== 0) {
          puzzle[row][col] = 0;
          cellsCleared++;
        }
      }
  
      return puzzle;
    }
  
    // Проверка на безопасность для числа
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
  
    // Перемешивание массива (для генерации случайных чисел)
    shuffleArray(array) {
      for (let i = array.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [array[i], array[j]] = [array[j], array[i]];
      }
      return array;
    }
  }
  
  // Инициализация игры
  document.addEventListener("DOMContentLoaded", () => {
    const game = new Sudoku();
  
    const boardElement = document.getElementById("sudoku-board");
    const generateBoardButton = document.getElementById("generate-board");
    const validateBoardButton = document.getElementById("validate-board");
    const generateSolvedBoardButton = document.getElementById("generate-solved-board");
  
    function renderBoard(board) {
      boardElement.innerHTML = ""; // Очищаем поле
  
      for (let row = 0; row < 9; row++) {
        for (let col = 0; col < 9; col++) {
          const cell = document.createElement("input");
          cell.type = "text";
          cell.className = "cell";
          cell.maxLength = 1;
          const value = board[row][col];
          cell.value = value === 0 ? "" : value;
          cell.dataset.row = row;
          cell.dataset.col = col;
  
          // Делаем клетки с начальными значениями незаполняемыми
          if (value !== 0) {
            cell.disabled = true;
            cell.classList.add("disabled");
          }
  
          // Обработчик ввода
          cell.addEventListener("input", (e) => {
            const val = parseInt(e.target.value, 10);
            if (!isNaN(val) && val >= 1 && val <= 9) {
              game.board[row][col] = val;
            } else {
              e.target.value = "";
              game.board[row][col] = 0;
            }
          });
  
          boardElement.appendChild(cell);
        }
      }
    }
  
    // Генерация нового пустого поля
    generateBoardButton.addEventListener("click", () => {
      game.resetBoard();
      game.generateBoard();
      const puzzle = game.createPuzzle(); // Создаем поле для игры
      renderBoard(puzzle); // Рендерим поле с случайными пустыми клетками
    });
  
    // Проверка корректности поля
    validateBoardButton.addEventListener("click", () => {
      const isValid = game.validateBoard();
      alert(isValid ? "Поле корректно!" : "Есть ошибки в поле.");
    });
  
    // Генерация решенного поля
    generateSolvedBoardButton.addEventListener("click", () => {
      game.generateBoard(); // Генерация решенного поля
      renderBoard(game.board);
    });
  
    renderBoard(game.board);
  });
  