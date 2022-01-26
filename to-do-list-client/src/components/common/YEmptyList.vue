<template>
  <div class="empty__list">
    <y-icon size="2x" icon="file"/>
    <p>{{message}}</p>
  </div>
</template>

<script>
export default {
  name: 'y-empty-list',
  props: {
    message: {
      type: String,
      default: () => '',
    },
  }
}
</script>

<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';
  .empty__list {
    @include flexRow;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    & > *:not(:last-child) {
      margin-right: 10px;
    }
    
  }
</style>