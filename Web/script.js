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
  