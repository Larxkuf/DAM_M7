document.addEventListener("DOMContentLoaded", () => {
  fetch('carta.xml')
    .then(response => {
      if (!response.ok) {
        throw new Error("No se pudo cargar el archivo XML.");
      }
      return response.text();
    })
    .then(xmlText => {
      const parser = new DOMParser();
      const xmlDoc = parser.parseFromString(xmlText, "application/xml");
      displayMenu(xmlDoc);
    })
    .catch(error => console.error("Error en la carga del XML:", error));
});

function displayMenu(xmlDoc) {
  const carta = xmlDoc.getElementsByTagName("carta")[0];
  const menus = carta.getElementsByTagName("menu");

  for (let menu of menus) {
    const menuName = menu.getElementsByTagName("nom")[0].textContent;
    const plats = menu.getElementsByTagName("plat");

    for (let plat of plats) {
      const platName = plat.getElementsByTagName("nom")[0].textContent;
      const description = plat.getElementsByTagName("descripcio")[0].textContent;
      const alergenos = plat.getElementsByTagName("alergenos")[0]?.textContent || "Ninguno";
      const picante = plat.getElementsByTagName("picante")[0]?.textContent || "No";
      const imageUrl = plat.getElementsByTagName("imagen")[0].textContent;
      const precio = plat.getElementsByTagName("precio")[0]?.textContent || "??";

      renderMenuItem(menuName, platName, description, alergenos, picante, imageUrl, precio);
    }
  }
}

function renderMenuItem(menu, name, description, alergenos, picante, imageUrl, precio) {
  const menuContainer = document.querySelector('.menu-container');
  const item = document.createElement('div');
  item.classList.add('menu-item');

  item.style.backgroundImage = `url(img/${imageUrl})`;

  item.innerHTML = `
    <div class="content">
      <h3>${name}</h3>
      <p>${description}</p>
      <p><strong>Alérgenos:</strong> ${alergenos}</p>
      <p><strong>Picante:</strong> ${picante}</p>
      <p><strong>Precio:</strong> ${precio}</p>
    </div>
    <div class="overlay"></div>
  `;

  menuContainer.appendChild(item);
}














