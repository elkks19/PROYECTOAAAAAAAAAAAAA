/*document.getElementById('product-form').addEventListener('submit', function(event) {
   event.preventDefault();


   var productPhoto = document.getElementById('product-photo').files[0];
   var productPrice = document.getElementById('product-price').value;
   var productCategories = document.getElementById('product-categories').value;
   var productQuantity = document.getElementById('product-quantity').value;

   
   console.log('Product Photo:', productPhoto);
   console.log('Product Price:', productPrice);
   console.log('Product Categories:', productCategories);
   console.log('Product Quantity:', productQuantity);
});
 

//drop
var dropArea = document.getElementById('drop-area');
var fileElem = document.getElementById('fileElem');
var preview = document.getElementById('preview');
var uploadText = document.getElementById('upload-text');

dropArea.addEventListener('dragover', function(e) {
 e.stopPropagation();
 e.preventDefault();
 uploadText.textContent = 'Arrastra o Suelta las imagenes';
});

dropArea.addEventListener('dragleave', function(e) {
 e.stopPropagation();
 e.preventDefault();
 uploadText.textContent = 'Arrastra o Suelta las imagenes';
});

dropArea.addEventListener('drop', function(e) {
 e.stopPropagation();
 e.preventDefault();
 uploadText.textContent = 'Cargando...';
 var files = e.dataTransfer.files;
 handleFiles(files);
});
//funcion para que se suba la imagen

function handleFiles(files) {
 for (var i = 0; i < files.length; i++) {
 var file = files[i];
 if (file.type.startsWith('image/')) {
   var img = document.createElement('img');
   img.classList.add('obj');
   img.file = file;
   var reader = new FileReader();
   reader.onload = (function(aImg) {
     return function(e) {
       aImg.src = e.target.result;
     };
   })(img);
   reader.readAsDataURL(file);
   data.push({
     photo: img.src,
     price: document.getElementById('price').value,
     categories: document.getElementById('categories').value,
     quantity: document.getElementById('quantity').value,
     description: document.getElementById('description').value
   });
   updateTable();
 }
 }
}
//subir a la tabla

function updateTable() {
 var tableBody = document.getElementById('productTable').getElementsByTagName('tbody')[0];
 tableBody.innerHTML = '';
 for (var i = 0; i < data.length; i++) {
 var row = tableBody.insertRow();
 var cell1 = row.insertCell(0);
 var cell2 = row.insertCell(1);
 var cell3 = row.insertCell(2);
 var cell4 = row.insertCell(3);
 var cell5 = row.insertCell(4);
 var cell6 = row.insertCell(5);
 cell1.innerHTML = '<img src="' + data[i].photo + '" width="50" height="50">';
 cell2.innerHTML = data[i].price;
 cell3.innerHTML = data[i].categories;
 cell4.innerHTML = data[i].quantity;
 cell5.innerHTML = data[i].description;
 cell6.innerHTML = '<button onclick="deleteRow(' + i + ')">Delete</button>';
 }
}

function deleteRow(index) {
 data.splice(index, 1);
 updateTable();
}*/
//para llenar los espacios
const form = document.getElementById('product-form');
form.addEventListener('submit', function(event) {
   event.preventDefault();
   const myFormData = new FormData(event.target);
   const formDataObj = {};
   myFormData.forEach((value, key) => (formDataObj[key] = value));

   const table = document.getElementById('productTable');
   const row = table.insertRow();

   const nameCell = row.insertCell();
   nameCell.innerHTML = formDataObj['product-name'];

   const priceCell = row.insertCell();
   priceCell.innerHTML = formDataObj['product-price'];

   const categoriesCell = row.insertCell();
   categoriesCell.innerHTML = formDataObj['product-categories'];

   const quantityCell = row.insertCell();
   quantityCell.innerHTML = formDataObj['product-quantity'];

   const descriptionCell = row.insertCell();
   descriptionCell.innerHTML = formDataObj['product-description'];
});
//acciones
function modifyProduct(button) {

   var row = button.parentNode.parentNode;

   var cells = row.getElementsByTagName('td');

   var productName = cells[1].innerText;
   var productPrice = cells[2].innerText;

}

function deleteProduct(button) {

   var row = button.parentNode.parentNode;


   row.parentNode.removeChild(row);
}

