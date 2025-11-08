<template>
  <div>
    <div class="table-header-input">
      <div class="header-input-right icon" :class="icon" v-if="icon"></div>
      <input :value="modelValue" class="header-left-input" type="text" :placeholder="placeholder" :style="getStyle"/>
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue'
const props = defineProps({
  icon: {
    type: String,
    default: ''
  },
  placeholder: {
    type: String,
    default: ''
  },
  objectStyle: {
    type: Object,
    default: () => ({})
  }
})
const modelValue = defineModel()

const getStyle = computed(() => {
  return {
    width: '200px',
    ...props.objectStyle
  }
})
</script>

<style scoped>
.table-header-input {
  position: relative;
}

.table-header-input input {
  text-overflow: ellipsis;
  padding: 2px 0 2px 34px;
  border: 1px solid #dddde4;
  outline: none;
  border-radius: 5px;
  height: 30px;
}
.table-header-input input::placeholder {
  color: #a4acb8;
  font-weight: 400;
}

.header-input-right {
  position: absolute;
  z-index: 1;
  width: 16px !important;
  height: 16px !important;
  left: 9px;
  top: 50%;
  transform: translateY(-50%);
}
</style>