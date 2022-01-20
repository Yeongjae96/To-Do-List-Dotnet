<template>
  <div id="content">
    <div id="content-header">
      <p class="content-header__text">
        Today ({{ currentDayString }})
      </p>
    </div>
    <div id="content-body">
      <slot></slot>
    </div>
  </div>

    
</template>
<script>
export default {
  name: 'y-content',
  props: {
    
  },
  data() {
    return {
      currentDay: new Date(),
    };
  },
  computed: {
    currentDayString() {
      return `${this.currentDay.getFullYear()}. ${this.currentDay.getMonth()+1}. ${this.currentDay.getDate()}.`;
    }
  },
}
</script>
<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';
  #content {
    @include flexColumn;
    width: 100%;
  }

  #content-header {
    @include flexRow;
    width: 100%;
    min-height: 70px;
    padding-bottom: 30px;
  }

  .content-header__text {
    color: $color-lilac;
    font-size: $size-large;
    font-weight: bold;
    width: 100%;
    text-align: center;
  }

  #content-body {
    padding: 30px;
    // height: 100%;  
    flex: 1;
  }
</style>