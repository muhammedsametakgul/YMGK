function showInfo(type) {
  const infoModal = document.getElementById("infoModal");
  const infoText = document.getElementById("infoText");

  let content;
  switch (type) {
    case "oyunlar":
      content = "Eğlenceli oyunlar ile uçakta vakit geçirin! Çocuklar için güvenli ve eğitici oyunlar sizi bekliyor!";
      break;
    case "bilgiler":
      content = "Uçakların nasıl çalıştığını merak ediyor musunuz? Uçak hakkında ilginç bilgilerle eğlenin!";
      break;
    case "bulmacalar":
      content = "Bulmacalar ve zeka oyunları ile beyninizi çalıştırın! Hem eğlenceli hem öğretici içerikler burada!";
      break;
    default:
      content = "İçerik yükleniyor...";
  }

  infoText.innerText = content;
  infoModal.style.display = "flex";
}

function closeInfo() {
  document.getElementById("infoModal").style.display = "none";
}

let currentIndex = 0;
const cards = document.querySelectorAll(".carousel-card");

function updateCarousel() {
  cards.forEach((card, index) => {
    card.classList.remove("active");
    if (index === currentIndex) {
      card.classList.add("active");
    }
  });
  document.querySelector(".carousel-track").style.transform = `translateX(-${currentIndex * 100}%)`;
}

function nextCard() {
  currentIndex = (currentIndex + 1) % cards.length;
  updateCarousel();
}

function prevCard() {
  currentIndex = (currentIndex - 1 + cards.length) % cards.length;
  updateCarousel();
}

updateCarousel();

let startX = 0;
let endX = 0;

document.querySelector(".carousel-track").addEventListener("touchstart", (e) => {
  startX = e.touches[0].clientX;
});

document.querySelector(".carousel-track").addEventListener("touchmove", (e) => {
  endX = e.touches[0].clientX;
});

document.querySelector(".carousel-track").addEventListener("touchend", () => {
  if (startX > endX + 50) {
    nextCard(); 
  } else if (startX < endX - 50) {
    prevCard(); 
  }
});

