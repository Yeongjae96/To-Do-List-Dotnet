<template>
  <div class="card">
    <div class="card__title">
      {{ name }}
    </div>
    <div class="card__content">
      <div class="">
        알림줄
      </div>
      <div class="todo__search">
        <y-input type="text" width="80%" height="30px" borderColor="gray"/>
        <y-button
          width="50px"
          height="30px"
          borderColor="black"
          backgroundColor="silver"
          text="추가"
        >등록</y-button>
      </div>
      <div class="">
        목록창
      </div>
    </div>
    <div class="card__tail">
      각종 아이콘 메뉴
    </div>
  </div>
</template>

<script>
import YInput from '@/components/YInput'
import YButton from '@/components/YButton'
export default {
  name: 'todo-list',
  components: {
    YInput,
    YButton,
  },
  // alternativeUrl: 'todo/todos',
  data() {
    return {
      name: 'TODO-LIST'
    };
  }
}
</script>

<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';
  
  .card {
    @include flexColumn($horizontal-align: flex-start, $vertical-align: flex-start);
    position: relative;
    width: 90%;
    height: 90%;
    margin: 0 auto;
    background-color: white;
    padding: 20px 20px 0px 20px;

    & > * {
      width: 100%;
    }

    & .card__title {
      font-size: 1.5rem;
      font-weight: bold;
      margin-bottom: 20px;
      padding-bottom: 10px;
      border-bottom: 1px solid #413e3e;
    }

    & .card__content > *:not(:last-child) {
      margin-bottom: 10px;
    }

    & .card__tail {
      position: absolute;
      bottom: 10px;
    }
  }

  .todo__search {
    @include flexRow;
    & > *:not(:last-child) {
      margin-right: 20px;
    }
    & > * {
      flex-grow: 1;
    }
  }


</style>