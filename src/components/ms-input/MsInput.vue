<template>
  <div>
    <div class="table-header-input">
      <div class="header-input-right icon" :class="icon" v-if="icon"></div>
      <input :value="modelValue" class="header-left-input" type="text" :placeholder="placeholder" :style="objectStyle"
        @input="updateInputValue" />
    </div>
  </div>
</template>

<script setup>
//  icon-search

const props = defineProps({
  icon: {
    type: String,
    default: ''
  },
  modelValue: {
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
const emit = defineEmits(['update:modelValue'])
const updateInputValue = () => {
  emit('update:modelValue', props.modelValue)
}
</script>

<style scoped>
.table-header-input {
  position: relative;
}

.table-header-input input {
  text-overflow: ellipsis;
  padding: 2px 0 2px 25px;
  border: 1px solid #dddde4;
  outline: none;
  border-radius: 5px;
  height: 30px;
}

.header-input-right {
  position: absolute;
  z-index: 1;
  width: 16px !important;
  height: 16px !important;
  left: 8px;
  top: 50%;
  transform: translateY(-50%);
}
</style>