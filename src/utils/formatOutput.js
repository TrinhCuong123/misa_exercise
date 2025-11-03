// format date dd/mm/yyyy
function formatDate(dateString) {
  if (!dateString) return ''
  const date = new Date(dateString)
  const day = String(date.getDate()).padStart(2, '0')
  const month = String(date.getMonth() + 1).padStart(2, '0')
  const year = date.getFullYear()
  return `${day}/${month}/${year}`
}

//format gender
function formatGender(genderCode) {
  if (genderCode === 0) return 'Nữ'
  else if (genderCode === 1) {
    return 'Nam'
  } else return '--'
}
// check null
function checkNull(value) {
  if (value === null) {
    return '--'
  } else if (value === '') {
    return ''
  } else return value
}
// check istalent pool detail
function checkIsTalentPoolDetail(value) {
  if (value === 0 || value === null) {
    return '--'
  } else return value
}

//check tt tiep nhan
function checkProbationInfoStatus(value) {
  if (value === 0) {
    return 'Chờ xác nhận'
  } else if (value === 1) {
    return 'Đã xác nhận'
  } else if (value === null) return '--'
}

//format offer status
function formatOfferStatus(statusCode) {
  if (statusCode === 1) {
    return 'Chờ xác nhận'
  } else if (statusCode === 2) {
    return 'Đã đồng ý'
  } else return '--'
}

function generateAvatar(name) {
  if (!name) return ''
  const initials = name
    .split(' ')
    .map((word) => word[0])
    .join('')
    .slice(0, 2)
    .toUpperCase()

  // Sử dụng màu từ trường avatarColor
  // const avatarColor = color || '#0078d4' // Mặc định nếu không có màu

  return initials
}

export {
  formatDate,
  formatGender,
  checkNull,
  checkIsTalentPoolDetail,
  checkProbationInfoStatus,
  formatOfferStatus,
  generateAvatar,
}
