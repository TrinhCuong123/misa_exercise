<template>
  <modal-popup @close-modal="closeModal">
    <template #title>Thêm ứng viên</template>
    <template #content>
      <div class="popup-content-fullname popup-input">
        <div>
          <label>Họ và tên</label>
          <span>*</span>
        </div>
        <div class="input-icon">
          <input id="candidateName" type="text" class="w-100 h-32px" placeholder="Nhập họ và tên" />
        </div>
      </div>
      <div class="popup-content-dobgender d-flex">
        <div class="popup-input popup-content-dob w-100 mr-10">
          <div class="d-flex justify-space-between">
            <label>Ngày sinh</label>
            <div class="content-dob-note d-flex align-center mr-10">
              <div>Ngày tháng năm</div>
              <div class="icon icon-down"></div>
            </div>
          </div>
          <div class="input-icon w-100">
            <DatePicker v-model="date" date-format="dd/mm/yy" placeholder="dd/MM/yyyy" show-icon fluid/>
          </div>
        </div>
        <div class="popup-input popup-content-gender w-100">
          <div>
            <div>
              <label>Giới tính</label>
            </div>
            <div class="input-icon input-icon-left">
              <input id="gender" class="h-32px" type="text" placeholder="Chọn giới tính" />
              <div class="icon-right icon icon-down"></div>
            </div>
          </div>
        </div>
      </div>

      <div class="popup-input popup-content-area">
        <div>
          <div>
            <label>Khu vực</label>
          </div>
          <div class="input-icon input-icon-left">
            <input id="areaName" class="h-32px" type="text" placeholder="Chọn khu vực" />
            <div class="icon-right icon icon-down"></div>
          </div>
        </div>
      </div>

      <div class="popup-content-phonenumbermail d-flex">
        <div class="popup-input popup-content-phonenumber w-100 mr-10">
          <div>
            <div>
              <label>Số điện thoại</label>
            </div>
            <div class="input-icon">
              <input id="mobile" class="h-32px" type="text" placeholder="Nhập số điện thoại" />
            </div>
          </div>
        </div>
        <div class="popup-input popup-content-email w-100">
          <div>
            <div>
              <label>Email</label>
            </div>
            <div class="input-icon">
              <input id="email" class="h-32px" type="text" placeholder="Nhập email" />
            </div>
          </div>
        </div>
      </div>
      <div class="popup-input popup-content-adress">
        <div>
          <div>
            <label>Địa chỉ</label>
          </div>
          <div class="input-icon">
            <input id="address" class="h-32px" type="text" placeholder="Nhập địa chỉ" />
          </div>
        </div>
      </div>
      <div class="popup-content-education">
        <div>Học vấn</div>
        <div>
          <div class="d-flex align-center">
            <div class="icon icon-dot mr-8"></div>
            <label>Trình độ đào tạo</label>
            <div class="input-icon">
              <input id="educationDegreeName" class="h-32px" type="text" placeholder="Nhập trình độ đào tạo" />
              <div class="icon-right icon icon-plus"></div>
            </div>
          </div>
          <div class="d-flex align-center">
            <div class="icon icon-dot mr-8"></div>
            <label>Nơi đào tạo</label>
            <div class="input-icon">
              <input id="educationPlaceName" class="h-32px" type="text" placeholder="Nhập nơi đào tạo" />
              <div class="icon-right icon icon-plus"></div>
            </div>
          </div>
          <div class="d-flex align-center">
            <div class="icon icon-dot mr-8"></div>
            <label>Chuyên ngành</label>
            <div class="input-icon">
              <input id="educationMajorName" class="h-32px" type="text" placeholder="Nhập chuyên ngành" />
              <div class="icon-right icon icon-plus"></div>
            </div>
          </div>
        </div>
      </div>
      <hr />
      <div class="popup-content-themhocvan d-flex align-center">
        <div class="icon icon-plus icon-plus-blue"></div>
        <div class="title-plus">Thêm học vấn</div>
      </div>
      <div class="popup-content-ungtuyen d-flex">
        <div class="popup-input content-data-apply w-100 mr-10">
          <div>
            <label>Ngày ứng tuyển</label>
            <span>*</span>
          </div>
          <div class="input-icon input-icon-left">
            <input id="applyDate" class="h-32px" type="text" placeholder="Chọn ngày ứng tuyển" />
            <div class="icon-right icon icon-down"></div>
          </div>
        </div>
        <div class="popup-input content-nguonungvien w-100">
          <div>
            <label>Nguồn ứng viên</label>
          </div>
          <div class="input-icon input-icon-left">
            <input v-model="channelName" id="Gender" class="h-32px" type="text" placeholder="Chọn nguồn ứng viên" />
            <div class="icon-right icon icon-down"></div>
          </div>
        </div>
      </div>
      <div class="popup-input popup-content-nhansu d-flex">
        <div class="content-mining-personnel w-100 mr-10">
          <div>
            <div>
              <label>Nhân sự khai thác</label>
            </div>
            <div class="input-icon input-icon-left">
              <input id="Gender" type="text" class="h-32px" placeholder="Chọn nhân sự khai thác" />
              <div class="icon-right icon icon-down"></div>
            </div>
          </div>
        </div>
        <div class="content-congtavien w-100">
          <div>
            <div>
              <label>Cộng tác viên</label>
            </div>
            <div class="input-icon input-icon-left">
              <input v-model="collaboratorName" id="collaboratorName" class="h-32px" type="text" placeholder="Chọn cộng tác viên" />
              <div class="icon-right icon icon-down"></div>
            </div>
          </div>
        </div>
      </div>
      <div class="popup-content-themnhanhnhansu d-flex">
        <div class="mr-8">
          <input id="Gender" class="h-32px" type="checkbox" />
        </div>
        <div>Thêm nhanh người tham chiếu vào kho ứng viên</div>
      </div>
      <div class="popup-content-themnguoigioithieu d-flex align-center">
        <div class="icon icon-plus icon-plus-blue"></div>
        <div class="title-plus">Thêm người giới thiệu</div>
      </div>
      <div class="popup-input popup-content-noilamviecgan">
        <div>
          <label>Nơi làm việc gần đây</label>
        </div>
        <div class="input-icon input-icon-left">
          <input id="Gender" class="h-32px" type="text" placeholder="Nhập nơi làm việc gần đây" />
        </div>
      </div>
      <hr />
      <div class="popup-content-themkinhnolamviec d-flex align-center">
        <div class="icon icon-plus icon-plus-blue"></div>
        <div class="title-plus">Thêm kinh nghiệm làm việc</div>
      </div>
      <div class="popup-input popup-content-noilamviec">
        <div>
          <div>
            <label>Nơi làm việc</label>
          </div>
          <div class="input-icon input-icon-left">
            <input v-model="workPlaceRecent" id="Gender" class="h-32px" type="text" placeholder="Nhập nơi làm việc" />
          </div>
        </div>
      </div>
      <div class="popup-input popup-thoigian">
        <div>
          <div>
            <label>Thời gian</label>
          </div>
          <div class="d-flex align-center">
            <div class="input-icon input-icon-left">
              <input id="Gender" type="text" class="h-32px" placeholder="MM/yyyy" />
            </div>
            <div>-</div>
            <div class="input-icon input-icon-left">
              <input id="Gender" type="text" class="h-32px" placeholder="MM/yyyy" />
            </div>
          </div>
        </div>
      </div>
      <div class="popup-input popup-content-vitricongviec">
        <div>
          <div>
            <label>Vị trí công việc</label>
          </div>
          <div class="input-icon input-icon-left">
            <input id="jobPositionName" class="h-32px" type="text" placeholder="Nhập vị trí công việc" />
          </div>
        </div>
      </div>
      <div class="popup-input popup-content-motacongviec">
        <div>
          <div>
            <label>Mô tả công việc</label>
          </div>
          <div class="input-icon input-icon-left">
            <input id="HireDate" class="h-32px" type="text" placeholder="Nhập mô tả công việc" />
          </div>
        </div>
      </div>
    </template>
    <template #footer>
      <div @click="closeModal" class="btn-close cursor-pointer">Hủy</div>
      <div class="btn-save cursor-pointer">Lưu</div>
    </template>
  </modal-popup>
</template>

<script setup>
import ModalPopup from '@/components/ms-popup/MsPopup.vue';
import DatePicker from 'primevue/datepicker';
import { ref } from 'vue';

const date = ref(null);
const emit = defineEmits(['closeModal']);
const closeModal = () => {
  emit('closeModal');
};
</script>

<style scoped>
/* style label */
/* .popup-input {} */

.popup-input label {
  font-size: 14px;
  font-weight: bold;
}

.popup-input span {
  color: red;
}

.content-dob-note div {
  color: #9e9e9e;
}

.content-dob-note div:nth-child(2) {
  background-color: #9e9e9e;
}

/* Style input */
.input-icon {
  position: relative;
  display: flex;
  flex: 1;
}

.input-icon input {
  margin: 5px 0;
  border: 1px solid #dddde4;
  padding: 8px 16px 8px 16px;
  height: 24px;
  width: 100%;
  box-sizing: border-box;
  color: #000000;
}

.input-icon .icon-left {
  background-color: #9e9e9e;
  position: absolute;
  z-index: 999;
  width: 16px !important;
  height: 16px !important;
  left: 8px;
  top: 50%;
  transform: translateY(-50%);
}

.input-icon .icon-right {
  background-color: #9e9e9e;
  position: absolute;
  z-index: 999;
  width: 16px !important;
  height: 16px !important;
  right: 8px;
  top: 50%;
  transform: translateY(-50%);
}

.icon-plus-blue {
  background-color: #2680eb !important;
}

.title-plus {
  color: #2680eb !important;
}

/* .popup-content-dob,
.popup-content-phonenumber,
.content-data-apply,
.content-mining-personnel {
  margin-right: 10px;
} */

.popup_content input {
  width: 100%;
}

.popup-content-education label {
  min-width: 150px;
  font-weight: bold;
}

.popup-content-education input {
  flex: 1;
}

.btn-close {
  padding: 7px 16px;
  border-radius: 5px;
}

.btn-save {
  padding: 7px 16px;
  background-color: #2680eb;
  color: #ffffff;
  border-radius: 5px;
}
.p-datepicker {
  width: 100%;
}
</style>