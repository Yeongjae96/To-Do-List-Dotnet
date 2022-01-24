<template>
  <div class="empty__list">
    <y-icon size="3x" icon="file"/>
    <p>{{message}}</p>
  </div>
</template>

<script>
import YIcon from '@/components/YIcon'
export default {
  name: 'y-empty-list',
  components: {
    YIcon,
  },
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