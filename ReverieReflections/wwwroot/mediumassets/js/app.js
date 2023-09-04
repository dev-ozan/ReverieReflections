window.onscroll = function () {
  scrollFunction();
};

function scrollFunction() {
  if (
    document.body.scrollTop > 450 ||
    document.documentElement.scrollTop > 450
  ) {
    document
      .querySelector(".topMenu")
      .style.setProperty("background-color", "#fff", "important");
    document
      .querySelector(".menuLinks ul li.get-started a")
      .classList.remove("btn-dark");
    document
      .querySelector(".menuLinks ul li.get-started a")
      .classList.add("btn-success");
  } else {
    document
      .querySelector(".topMenu")
      .style.setProperty("background-color", "#ffc017", "important");
    document
      .querySelector(".menuLinks ul li.get-started a")
      .classList.remove("btn-success");
    document
      .querySelector(".menuLinks ul li.get-started a")
      .classList.add("btn-dark");
  }
}
