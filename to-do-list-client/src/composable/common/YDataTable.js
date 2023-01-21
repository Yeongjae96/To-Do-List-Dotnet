import { ref } from "vue";

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

/*
  1. type : 이벤트 타입 Ex) click
  2. propertyName: 속성명 Ex) completed
  3. value: emit시킬 속성값
*/
export function dtEmit(obj) {
  if (!obj.context) throw new Error('need current context');
  const { emit } = obj.context
  emit("dtEvent", obj);
}

export function resizeItem({ headerInfo, item }) {
  if (headerInfo.length <= 0) throw new Error("헤더 정보가 없습니다.");
  if (!(item && item.value)) throw new Error("해당 item정보가 없습니다.");

  // flex를 넣고 나머지는 flexGrow를 한다.
  item.value.style.display = "flex";
  // item.value.style.minWidth="100%";
  // 하위 태그 width 보정
  const itemChildren = Array.from(item.value.children);
  itemChildren.forEach((item, idx) => {
    const itemHeader = headerInfo[idx];
    
    // width 조정
    if (itemHeader.width === "*" || !itemHeader.width) {
      item.style.flexGrow = 1;
      item.style.paddingLeft='5px';
      item.style.paddingRight='5px';
    } else {
      item.style.minWidth = String(Number(itemHeader.width.replace('px', '')) + 1) + 'px';
    }

    // text align 조정
    if (itemHeader.align) {
      item.style.display = "flex";
      item.style.justifyContent = calcTextAlign(itemHeader.align);
    }
  });
}
