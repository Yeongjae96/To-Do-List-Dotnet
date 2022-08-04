<template>
  <li class="todo__item" ref="todoItem">
    <div class="todo__subject" :class="{ completed }" @dblclick="onDblClickSubject" :title="displayTitle">
      <y-input
        :isEdit="isEdit"
        width="99%"
        height="30px"
        borderStyle="0.75px solid #EE5058"
        v-model="displayTitle"
        @enter="onEnterSubject"
        @focusout="onFocusoutSubject"
      />

    </div>
    <div class="todo__completed" @click="onClick('completed')">
      <y-icon name="circle" :color="completedColor" />
    </div>
    <div class="todo__tag" @click="onClick('tag')">
      <y-icon name="tags" fontSize="1.5rem" />
    </div>
    <div class="todo__reg_date" :title="regDate">
      {{ regDate }}
    </div>
    <div class="todo__buttons">
      <y-button
        width="50px"
        height="40px"
        backgroundColor="lightblue"
        text="수정"
        color="white"
        @click="onClickUpdate"
      />
      <y-button
        width="50px"
        height="40px"
        backgroundColor="#EE5058"
        text="삭제"
        color="white"
        @click="deleteTodo(no)"
      />
    </div>
  </li>
</template>

<script>
import { ref, toRefs, onMounted, watch, computed } from 'vue'
import { resizeItem } from '@/composable/common/YDataTable'
import { TODO } from '../../utils/Const';
import { emit } from '@/composable/common/YDataTable'
export default {
  name: "todo-item",
  inheritAttrs: false,
  // dtHeader는 yDataTable의 template에 해당하는 부분에서만 사용한다. (우선순위일뿐 yDataTable 호출부분에서 데이터로 넘길수 있으므로 테스트용도로 구현함.)
  dtHeader: [ 
    {
      type: "text",
      key: "title",
      text: "제목",
      width: "*",
    },
    {
      // type: "icon",
      key: "completed",
      text: "완료여부",
      width: "100px",
      // extensionProperties: {
      //   name: "circle",
      // },
      // compute: {
      //   color: (data) => TODO.completedColor[data.completed],
      // },
      align: 'center'
    },
    {
      // type: "custom",
      key: "tag",
      text: "태그",
      width: "100px",
      align: 'center'
    },
    {
      // type: "date",
      key: "regDate",
      text: "작성일",
      width: "250px",
      align: 'center'
      // editable: false,
    },
    {
      // type: "custom",
      text: "추가기능",
      width: "150px",
      align: 'center'
    },
  ],
  props: {
    no: {
      type: Number,
      default: 1,
    },
    id: {
      type: [String, Number],
      default: () => "",
    },
    title: {
      type: String,
      default: () => "",
    },
    flag: {
      type: String,
      default: () => "",
    },
    regDate: {
      type: String,
      default: () => "",
    },
    completed: {
      type: Boolean,
      default: () => false,
    },
    /* YDataTable용 Props */
    isDataTable: {
      type: Boolean,
      default: false,
    },
    dtHeader: {
      type: Array,
      default: () => [],
    }
    /* YDataTable용 Props */
  },
  setup(props) {
    // 변수    
    const { title, completed, dtHeader, no } = toRefs(props);
    const isEdit = ref(false);

    // initial Value
    let displayTitle = ref(props.title);
    
    const todoItem = ref(null);

    watch(title, () => {
      displayTitle.value = title.value;
    })

    // 로직
    const changeSubject = (value, t) => {
      isEdit.value = false;
  
      if (!value || value.trim() === '' || displayTitle.value === title.value) {
        displayTitle.value = title.value;
      } else {
        // emit('update', { no: no.value, title: value})
      }
    }

    // changeMode Event
    const onDblClickSubject = (e) => {
      isEdit.value = true;
    }

    // 색깔
    const completedColor = computed(() => TODO.completedColor[completed.value])

    // changeSubject Event
    const onEnterSubject = changeSubject;
    const onFocusoutSubject = changeSubject;

    const onClickUpdate = (e) => {
      // emit('detailUpdate', no.value);
    }

    const onClick = (tagName) => {
      console.log('test', tagName);
      emit({
        type: 'click',
        propertyName: tagName,
        value: {
          no: no.value,
          title: title.value,
        }
      })
      // emit('click', { tagName, no: no.value })
    }

    // Width 보정
    onMounted(() => {
      resizeItem({ headerInfo: dtHeader.value, item: todoItem, });
    });

    return {
      displayTitle,
      isEdit, 
      todoItem,
      completedColor,
      onDblClickSubject,
      onEnterSubject,
      onFocusoutSubject,
      onClickUpdate,
      onClick
    }
  },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin.scss";


.todo__item {
  @include flexRow;
  max-height: 30px;

  &:not(:last-child) {
    margin-bottom: 20px;
  }

  & > * {
    @include flexRow;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    // border-bottom: 1px solid black;
  }

  & .todo__subject {
    width: 40%;
  }

  & .todo__completed {
    width: 10%;
    cursor: pointer;
  }

  & .todo__tag {
    width: 10%;
  }
  & .todo__reg_date {
    width: 15%;
  }

  & .todo__buttons {
    width: 10%;

    @include notLastChild {
      margin-right: 5px;
    }
  }

  .completed {
    text-decoration: line-through;
  }
}
</style>
