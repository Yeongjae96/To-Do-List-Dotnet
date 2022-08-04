import { getCurrentInstance, ref } from "vue";

const alignMap = {
  left: "left",
  center: "center",
  right: "right",
};

export function getHeaderData(data) {
  return ref(data);
}

export function calcTextAlign(align) {
  return alignMap[align] || "left";
}

export function emit(obj) {
  console.log(getCurrentInstance());
  const { emit } = getCurrentInstance();
  emit("dtEvent", obj);
}

export function resizeItem({ headerInfo, item }) {
  if (headerInfo.length <= 0) throw new Error("헤더 정보가 없습니다.");
  if (!(item && item.value)) throw new Error("해당 item정보가 없습니다.");

  // flex를 넣고 나머지는 flexGrow를 한다.
  item.value.style.display = "flex";
  // 하위 태그 width 보정
  const itemChildren = Array.from(item.value.children);
  itemChildren.forEach((item, idx) => {
    const itemHeader = headerInfo[idx];

    // width 조정
    if (itemHeader.width === "*" || !itemHeader) {
      item.style.flexGrow = 1;
    } else {
      item.style.width = itemHeader.width;
    }

    // text align 조정
    if (itemHeader.align) {
      item.style.display = "flex";
      item.style.justifyContent = calcTextAlign(itemHeader.align);
    }
  });
}
