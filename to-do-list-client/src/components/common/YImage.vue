<template>
  <img :src="image" :width="width" :height="height" />
</template>
<script>
import { toRefs, computed } from 'vue'
export default {
  name: 'y-image',
  props: {
    src: {
      type: String,
      required: true,
    },
    width: {
      type: String,
      default: '40',
    },
    height: {
      type: String,
      default: '40',
    }
  },
  setup(props) {
    const { src: imageSrc, width, height } = toRefs(props);
    const image = computed(() => require(`@/assets/${imageSrc.value ? imageSrc.value : 'notexists.png'}`))
    return {
      image,
      width,
      height,
    }
  },
}
</script>
